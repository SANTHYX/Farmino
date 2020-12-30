import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from '../views/Home.vue';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
  },
  {
    path: '/auctions',
    name: 'Auctions',
    component: () => import('../views/Auctions.vue'),
  },
  {
    path: '/register',
    name: 'Register',
    component: () => import('../views/Register.vue'),
  },
  {
    path: '/offers',
    name: 'Offers',
    component: () => import('../views/Offers.vue'),
  },
  {
    path: '/signin',
    name: 'SignIn',
    component: () => import('../views/SignIn.vue'),
  },
  {
    path: '/search',
    name: 'Search',
    component: () => import('../views/Search.vue'),
  },
  {
    path: '/profile/:login',
    name: 'Profile',
    params: true,
    component: () => import('../views/Profile.vue'),
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
