import React, { PureComponent } from 'react';
import { connect } from 'dva';
import Link from 'umi/link';
import router from 'umi/router';
import { Card, Row, Col, Icon, Avatar, Tag, Divider, Spin, Input, message, Form } from 'antd';
import GridContent from '@/components/PageHeaderWrapper/GridContent';
import styles from './Center.less';

@connect(({ loading, global, project }) => ({
  listLoading: loading.effects['list/fetch'],
  currentUser: global.currentUser,
  currentUserLoading: loading.effects['global/getCurrentLoginInformations'],
  project,
  projectLoading: loading.effects['project/fetchNotice'],
}))
class Center extends PureComponent {
  state = {
    newTags: [],
    oldValue: '',
    newValue: '',
  };

  componentDidMount() {
    const { dispatch } = this.props;
    dispatch({
      type: 'global/getCurrentLoginInformations',
    });
    dispatch({
      type: 'list/fetch',
      payload: {
        count: 8,
      },
    });
    dispatch({
      type: 'project/fetchNotice',
    });
  }

  oldChange = e => {
    this.setState({ oldValue: e.target.value });
  };
  newChange = e => {
    this.setState({ newValue: e.target.value });
  };
  savePWD=e=>{
    message.info(this.state.oldValue+'|'+this.state.newValue);

    dispatch({
      type: 'systemSetting/apiCreateRotation',
      payload: {
        currentPassword: this.state.oldValue,
        newPassword: this.state.newValue,
      },
    });
  };
  handleSubmit = e => {
    e.preventDefault();
    this.props.form.validateFields((err, values) => {
      if (!err) {
        console.log('Received values of form: ', values);
      }
    });
    
    dispatch({
      type: 'systemSetting/apiCreateRotation',
      payload: {
        currentPassword: this.state.oldValue,
        newPassword: this.state.newValue,
      },
    });
  };

  handleInputConfirm = () => {
    const { state } = this;
    const { inputValue } = state;
    let { newTags } = state;
    if (inputValue && newTags.filter(tag => tag.label === inputValue).length === 0) {
      newTags = [...newTags, { key: `new-${newTags.length}`, label: inputValue }];
    }
    this.setState({
      newTags,
      oldValue: '',
      newValue: '',
    });
  };

  render() {
    const { newTags, inputVisible, inputValue } = this.state;
    const {
      listLoading,
      currentUser,
      currentUserLoading,
      project: { notice },
      projectLoading,
      match,
      location,
      children,
    } = this.props;

    const operationTabList = [
      {
        key: 'articles',
        tab: (
          <span>
            文章 <span style={{ fontSize: 14 }}>(8)</span>
          </span>
        ),
      },
      {
        key: 'applications',
        tab: (
          <span>
            应用 <span style={{ fontSize: 14 }}>(8)</span>
          </span>
        ),
      },
      {
        key: 'projects',
        tab: (
          <span>
            项目 <span style={{ fontSize: 14 }}>(8)</span>
          </span>
        ),
      },
    ];

    return (
      // <GridContent className={styles.userCenter}>
      //   <Row gutter={24}>
      //     <Col lg={7} md={24}>
            <Card style={{ marginBottom: 24 }} loading={currentUserLoading}>
              {currentUser && Object.keys(currentUser).length ? (
                <div>
                  <div className={styles.avatarHolder}>
                    <img alt="" src={currentUser.profilePictureId != null ? currentUser.profilePictureId : 'https://gw.alipayobjects.com/zos/rmsportal/BiazfanxmamNRoxxVxka.png'} />
                    <div className={styles.name}>{currentUser.name}</div>
                    <div>{currentUser.emailAddress}</div>
                  </div>
                  <div className={styles.detail}>
                    <p>
                      <i className={styles.title} />
                      常州绍鼎密封科技有限公司
                    </p>
                  </div>
                  <Divider dashed />              
                  <Form onSubmit={this.handleSubmit} className="login-form">
                    <Form.Item>
                      {getFieldDecorator('password', {
                        rules: [{ required: true, message: '请输入原密码!' }],
                      })(
                        <Input
                          prefix={<Icon type="lock" style={{ color: 'rgba(0,0,0,.25)' }} />}
                          type="password"
                          placeholder="原密码"
                        />,
                      )}
                    </Form.Item>
                    <Form.Item>
                      {getFieldDecorator('password', {
                        rules: [{ required: true, message: '请输入新密码!' }],
                      })(
                        <Input
                          prefix={<Icon type="lock" style={{ color: 'rgba(0,0,0,.25)' }} />}
                          placeholder="新密码"
                        />,
                      )}
                    </Form.Item>
                  </Form>

                  {/* <div className={styles.Input}>
                    <p>
                      <i className={styles.title} />
                      原密码：
                    <Input placeholder="原密码" style={{ width: 200 }} onChange={this.oldChange.bind(this)}/>
                    </p>
                    <p>
                      <i className={styles.title} />
                      新密码：
                    <Input placeholder="新密码" style={{ width: 200 }} onChange={this.newChange.bind(this)}/>
                    </p>
                    <button type="primary" onClick={this.savePWD.bind(this)} style={{marginLeft:20}} >修改</button>
                  </div> */}
                  <Divider dashed />
                  <div className={styles.tags}>
                    <div className={styles.tagsTitle}>角色</div>
                    {inputVisible && (
                      <Input
                        ref={this.saveInputRef}
                        type="text"
                        size="small"
                        style={{ width: 78 }}
                        value={inputValue}
                        onChange={this.handleInputChange}
                        onBlur={this.handleInputConfirm}
                        onPressEnter={this.handleInputConfirm}
                      />
                    )}
                    {!inputVisible && (
                      <Tag
                        onClick={this.showInput}
                        style={{ background: '#fff', borderStyle: 'dashed' }}
                      >
                        <Icon type="plus" />
                      </Tag>
                    )}
                  </div>
                  <div ></div>
                  {/* <Divider style={{ marginTop: 16 }} dashed />
                  <div className={styles.team}>
                    <div className={styles.teamTitle}>团队</div>
                    <Spin spinning={projectLoading}>
                      <Row gutter={36}>
                        {notice.map(item => (
                          <Col key={item.id} lg={24} xl={12}>
                            <Link to={item.href}>
                              <Avatar size="small" src={item.logo} />
                              {item.member}
                            </Link>
                          </Col>
                        ))}
                      </Row>
                    </Spin>
                  </div> */}
                </div>
              ) : (
                'loading...'
              )}
            </Card>
          // </Col>
          /*{ <Col lg={17} md={24}>
            <Card
              className={styles.tabsCard}
              bordered={false}
              tabList={operationTabList}
              activeTabKey={location.pathname.replace(`${match.path}/`, '')}
              onTabChange={this.onTabChange}
              loading={listLoading}
            >
              {children}
            </Card>
          </Col> }*/
      //   </Row>
      // </GridContent>
    );
  }
}

const WrappedNormalLoginForm = Form.create({ name: 'normal_login' })(Center);

export default Center;
