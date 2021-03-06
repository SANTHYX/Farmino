import { isAuthorized } from '../guards';

const profileRoutes = [
  {
    path: '/profile',
    redirect: 'home',
    component: () => import('@/views/profile/Profile.vue'),
    beforeEnter: isAuthorized,
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
];

export default profileRoutes;
