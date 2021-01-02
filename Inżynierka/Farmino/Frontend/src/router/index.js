import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

const routes = [
  {
    path: '/auctions',
    name: 'auctions',
    component: () => import('@/views/Auctions.vue'),
  },
  {
    path: '/register',
    name: 'register',
    component: () => import('@/views/Register.vue'),
  },
  {
    path: '/offers',
    name: 'offers',
    component: () => import('@/views/Offers.vue'),
  },
  {
    path: '/login',
    name: 'login',
    component: () => import('@/views/Login.vue'),
  },
  {
    path: '/search',
    name: 'search',
    component: () => import('@/views/Search.vue'),
  },
  {
    path: '/profile',
    redirect: 'home',
    component: () => import('@/views/Profile.vue'),
    children: [
      {
        path: '/profile/:id',
        name: 'profile',
        props: true,
        component: () => import('@/components/dashboards/ProfileCard.vue'),
      },
      {
        path: 'create-profile',
        name: 'create-profile',
        component: () => import('@/components/forms/profile/CreateProfile.vue'),
      },
      {
        path: 'edit-profile',
        name: 'edit-profile',
        component: () => import('../components/forms/profile/EditProfileForm.vue'),
      },
      {
        path: 'edit-address',
        name: 'edit-address',
        component: () => import('../components/forms/profile/EditAddressForm.vue'),
      },
    ],
  },
  {
    path: '/',
    name: 'home',
    component: () => import('../views/Home.vue'),
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
