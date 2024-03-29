import { isAuthorized, isFarmer, haveProfile } from '../guards';

const offerRoutes = [
  {
    path: '/offers/my-offers',
    name: 'my-offers',
    component: () => import('@/views/offers/MyOffers.vue'),
    beforeEnter: isAuthorized,
  },

  {
    path: '/offers/:id/make-order',
    name: 'make-order',
    props: true,
    component: () => import('@/views/offers/MakeOrder.vue'),
    beforeEnter: isFarmer,
  },

  {
    path: '/offers/:id/custom-address',
    name: 'custom-address',
    props: true,
    component: () => import('@/views/offers/CustomAddress.vue'),
    beforeEnter: isAuthorized,
  },

  {
    path: '/offers/:id/summary',
    name: 'summary',
    props: true,
    component: () => import('@/views/orders/Summary.vue'),
    beforeEnter: isAuthorized,
  },

  {
    path: '/offers/offer-creator',
    name: 'offer-creator',
    component: () => import('@/views/offers/OfferCreate.vue'),
    beforeEnter: haveProfile,
  },

  {
    path: '/offers/offer-editor/:id',
    name: 'offer-editor',
    props: true,
    component: () => import('@/views/offers/EditOffer.vue'),
    beforeEnter: isAuthorized,
  },

  {
    path: '/offers/observed',
    name: 'observed',
    component: () => import('@/views/offers/Observed.vue'),
    beforeEnter: isAuthorized,
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
