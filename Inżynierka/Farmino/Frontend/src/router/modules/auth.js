import localStorageManager from '../../plugins/localStorageManager';

const authRoutes = [
  {
    path: '/login',
    name: 'login',
    component: () => import('@/views/login/Login.vue'),
    beforeEnter(from, to, next) {
      if (localStorageManager.isAuthorized()) {
        next({ path: '*' });
      } else next();
    },
  },
  {
    path: '/register',
    name: 'register',
    component: () => import('@/views/register/Register.vue'),
    beforeEnter(from, to, next) {
      if (localStorageManager.isAuthorized()) {
        next({ path: '*' });
      } else next();
    },
  },
];

export default authRoutes;
