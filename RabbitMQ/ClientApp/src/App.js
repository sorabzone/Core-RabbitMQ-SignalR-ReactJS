import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import FetchRabbitMQMassages from './components/FetchRabbitMQMassages';

export default () => (
  <Layout>
    <Route path='/' component={FetchRabbitMQMassages} />
  </Layout>
);
