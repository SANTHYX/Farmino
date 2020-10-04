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
    name: 'Auctions',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/shared/Auctions.vue'),
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
