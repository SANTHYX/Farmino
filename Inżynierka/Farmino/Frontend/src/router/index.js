import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from '../views/Home.vue';
import Profile from '../views/Profile.vue';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    component: Home,
  },
  {
    path: '/auctions',
    component: () => import('../views/Auctions.vue'),
  },
  {
    path: '/register',
    component: () => import('../views/Register.vue'),
  },
  {
    path: '/offers',
    component: () => import('../views/Offers.vue'),
  },
  {
    path: '/signin',
    component: () => import('../views/SignIn.vue'),
  },
  {
    path: '/search',
    component: () => import('../views/Search.vue'),
  },
  {
    path: '/profile/:login',
    params: true,
    component: Profile,
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
