import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from '../views/shared/Home.vue';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
  },
  {
    path: '/auctions',
    name: 'auctions',
    component: () => import(/* webpackChunkName: "auctions" */ '../views/shared/Auctions.vue'),
  },
  {
    path: '/offers',
    name: 'offers',
    component: () => import(/* webpackChunkName: "offers" */ '../views/shared/Offers.vue'),
  },
  {
    path: '/register',
    name: 'register',
    component: () => import(/* webpackChunkName: "register" */ '../views/shared/Register.vue'),
  },
  {
    path: '/login',
    name: 'login',
    component: () => import(/* webpackChunkName: "register" */ '../views/shared/Login.vue'),
  },
  {
    path: '*',
    redirect: {
      name: 'Home',
    },
  },
];

const router = new VueRouter({
  routes,
  mode: 'history',
});

export default router;
