const offerRoutes = [
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
    path: '/offers/observed',
    name: 'observed',
    component: () => import('@/views/offers/Observed.vue'),
  },
];

export default offerRoutes;
