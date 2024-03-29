import Vue from 'vue';
import VueRouter from 'vue-router';
import profileRoutes from './modules/proflie';
import authRoutes from './modules/auth';
import offerRoutes from './modules/offers';
import orderRoutes from './modules/orders';

Vue.use(VueRouter);

const routes = [
  ...orderRoutes,
  ...offerRoutes,
  ...profileRoutes,
  ...authRoutes,
  {
    path: '/',
    name: 'home',
    component: () => import('@/views/home/Home.vue'),
  },
  {
    path: '*',
    redirect: {
      name: 'home',
    },
  },
];

const router = new VueRouter({
  routes,
  mode: 'history',
});

export default router;
