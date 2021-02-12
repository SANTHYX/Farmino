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
    path: '/auctions/:id',
    name: 'auction',
    props: true,
    component: () => import('@/views/auctions/Auction.vue'),
  },
  {
    path: '/auctions/auction-creator',
    name: 'auction-creator',
    component: () => import('@/views/auctions/AuctionCreator.vue'),
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
    path: '/offers/my-offers',
    name: 'my-offers',
    component: () => import('@/views/offers/MyOffers.vue'),
  },
  {
    path: '/offers/:id',
    name: 'offer',
    props: true,
    component: () => import('@/views/offers/Offer.vue'),
  },
  {
    path: '/offers/:id/make-order',
    name: 'make-order',
    props: true,
    component: () => import('@/views/offers/MakeOrder.vue'),
  },
  {
    path: '/offers/:id/summary',
    name: 'summary',
    props: true,
    component: () => import('@/views/orders/Summary.vue'),
  },
  {
    path: '/offers/offer-creator',
    name: 'offer-creator',
    component: () => import('@/views/offers/OfferCreate.vue'),
  },
  {
    path: '/orders',
    redirect: 'home',
    name: 'orders',
    component: () => import('@/views/orders/Orders.vue'),
  },
  {
    path: '/orders/my-orders',
    name: 'my-orders',
    component: () => import('@/views/orders/MyOrders.vue'),
  },
  {
    path: '/orders/my-delivers',
    name: 'my-delivers',
    component: () => import('@/views/orders/MyDelivers.vue'),
  },
  {
    path: '/orders',
    redirect: 'home',
    component: () => import('@/views/orders/Order.vue'),
    children: [
      {
        path: '/orders/:id',
        name: 'order',
        props: true,
        component: () => import('../components/templates/OrderTemplate.vue'),
      },
      {
        path: '/orders/:id/release',
        name: 'order-release',
        props: true,
        component: () => import('../components/forms/order/RealisationForm.vue'),
      },
    ],
  },
  {
    path: '/login',
    name: 'login',
    component: () => import('@/views/login/Login.vue'),
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
