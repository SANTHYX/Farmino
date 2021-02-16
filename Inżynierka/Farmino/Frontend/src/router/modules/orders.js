const orderRoutes = [
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
    querry: {},
    component: () => import('@/views/orders/MyDelivers.vue'),
  },
  {
    path: '/orders/daily-delivers',
    component: () => import('@/views/orders/DailyDelivers.vue'),
    children: [
      {
        path: '',
        name: 'daily-delivers',
        component: () => import('../components/lists/ClientsOrdersList.vue'),
      },
      {
        path: ':id',
        name: 'daily-deliver-overview',
        props: true,
        component: () => import('../components/cards/DeliverDetails.vue'),
      },
    ],
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
];
export default orderRoutes;
