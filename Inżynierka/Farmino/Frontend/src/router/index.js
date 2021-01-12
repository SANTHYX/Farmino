import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

const routes = [
  {
    path: '/auctions',
    name: 'auctions',
    component: () => import('@/views/auctions/Auctions.vue'),
  },
  {
    path: '/register',
    name: 'register',
    component: () => import('@/views/register/Register.vue'),
  },
  {
    path: '/offers',
    name: 'offers',
    component: () => import('@/views/offers/Offers.vue'),
  },
  {
    path: '/offers/offer-creator',
    name: 'offer-creator',
    component: () => import('@/views/offers/OfferCreate.vue'),
  },
  {
    path: '/login',
    name: 'login',
    component: () => import('@/views/login/Login.vue'),
  },
  {
    path: '/search',
    name: 'search',
    component: () => import('@/views/search/Search.vue'),
  },
  {
    path: '/profile',
    redirect: 'home',
    component: () => import('@/views/profile/Profile.vue'),
    children: [
      {
        path: '/profile/:id',
        name: 'profile',
        props: true,
        component: () => import('@/components/cards/ProfileCard.vue'),
      },
      {
        path: 'create-profile',
        name: 'create-profile',
        component: () => import('@/components/forms/profile/CreateProfileForm.vue'),
      },
      {
        path: 'edit-profile',
        name: 'edit-profile',
        component: () => import('@/components/forms/profile/EditProfileForm.vue'),
      },
      {
        path: 'edit-address',
        name: 'edit-address',
        component: () => import('@/components/forms/profile/EditAddressForm.vue'),
      },
    ],
  },
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
