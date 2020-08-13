import React, { Component } from 'react';
import { Route, Switch, Redirect } from 'react-router';
import { Layout } from './components/layout/Layout';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import './custom.css'
import Task from './components/task/Task';
import TopUsers from './components/topUsers/TopUsers';
import Error from './components/error/Error';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>
            <Switch>
                <AuthorizeRoute path="/Solve" component={Task} />
                <AuthorizeRoute path="/Top3" component={TopUsers} />
                <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
                <AuthorizeRoute exact path="/"><Redirect to="/Solve" /></AuthorizeRoute>
                <AuthorizeRoute path='/error' component={Error} />
                <Route path="*">
                    <h2>404, Page Not Found</h2>
                </Route>
            </Switch>
      </Layout>
    );
  }
}
