import React, { Component } from 'react';
import { Route , Redirect, Switch} from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import About from './components/About';

import './custom.css'
import { Anonymous } from './components/Anonymous';
import { Login } from './components/Login';
import { Register } from './components/Register';

export default class App extends Component {
  static displayName = App.name;


  render () {
    return (
      <Layout>
        <Switch>
        <Route path='/register' component={Register}></Route>
        <Route path='/login' component={Login}/> 
        <Route path='/about' component={About}/>
        <Route path='/:id' component={Anonymous}/>
        <Route path='/' exact component={Home} />
        <Redirect to='/:id'/>
        </Switch>
      </Layout>
    );
  }
}
