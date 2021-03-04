import loacalStorageManager from '../../plugins/localStorageManager';
import store from '../../store/store';

const offerRoutes = [
  {
    path: '/offers/my-offers',
    name: 'my-offers',
    component: () => import('@/views/offers/MyOffers.vue'),
    beforeEnter(to, from, next) {
      if (!loacalStorageManager.isAuthorized()) {
        next({ path: '*' });
      } else next();
    },
  },
  {
    path: '/offers/:id/make-order',
    name: 'make-order',
    props: true,
    component: () => import('@/views/offers/MakeOrder.vue'),
    beforeEnter(to, from, next) {
      if (!loacalStorageManager.isAuthorized()) {
        next({ name: 'login', query: { redirect: to.fullPath } });
      }
      if (store.state.offer.offer.farmer.user.userName === loacalStorageManager.getUserName()) {
        next(false);
      } else next();
    },
  },
  {
    path: '/offers/:id/custom-address',
    name: 'custom-address',
    props: true,
    component: () => import('@/views/offers/CustomAddress.vue'),
    beforeEnter(to, from, next) {
      if (!loacalStorageManager.isAuthorized()) {
        next({ path: '*' });
      } else next();
    },
  },
  {
    path: '/offers/:id/summary',
    name: 'summary',
    props: true,
    component: () => import('@/views/orders/Summary.vue'),
    beforeEnter(to, from, next) {
      if (!loacalStorageManager.isAuthorized()) {
        next({ path: '*' });
      } else next();
    },
  },
  {
    path: '/offers/offer-creator',
    name: 'offer-creator',
    component: () => import('@/views/offers/OfferCreate.vue'),
    beforeEnter(to, from, next) {
      if (!loacalStorageManager.isAuthorized()) {
        next({ path: '*' });
      } else next();
    },
  },
  {
    path: '/offers/observed',
    name: 'observed',
    component: () => import('@/views/offers/Observed.vue'),
    beforeEnter(to, from, next) {
      if (!loacalStorageManager.isAuthorized()) {
        next({ path: '*' });
      } else next();
    },
  },
  {
    path: '/offers/:id',
    name: 'offer',
    props: true,
    component: () => import('@/views/offers/Offer.vue'),
  },
  {
    path: '/offers',
    name: 'offers',
    component: () => import('@/views/offers/Offers.vue'),
  },
];

export default offerRoutes;
