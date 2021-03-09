const authRoutes = [
  {
    path: '/login',
    name: 'login',
    component: () => import('@/views/login/Login.vue'),
  },

  {
    path: '/register',
    name: 'register',
    component: () => import('@/views/register/Register.vue'),
  },
];

export default authRoutes;
