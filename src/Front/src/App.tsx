import React, { Component } from 'react';
import { Route } from 'react-router'
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { ChatPage } from './components/ChatPage';
import { Chats } from './components/Chats';
import { StatsPage } from './components/StatsPage';
import Account from './projects/finodays/components/Account';
import './App.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        {/* <Route exact path='/chat/:chatId' component={ChatPage} />
        <Route exact path='/chat' component={Chats} />
        <Route exact path='/stats' component={StatsPage} /> */}
        <Route exact path='/finodays' component={Account} />
      </Layout>
    );
  }
}
