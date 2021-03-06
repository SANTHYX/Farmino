import { isAuthorized, haveProfile } from '../guards';

const auctionRoutes = [
  {
    path: '/auctions/my-auctions',
    name: 'my-auctions',
    component: () => import('@/views/auctions/MyAuctions.vue'),
    beforeEnter: isAuthorized,
  },
  {
    path: '/auctions/followed',
    name: 'followed',
    component: () => import('@/views/auctions/FollowedAuctions.vue'),
    beforeEnter: isAuthorized,
  },
  {
    path: '/auctions/auction-creator',
    name: 'auction-creator',
    component: () => import('@/views/auctions/AuctionCreate.vue'),
    beforeEnter: haveProfile,
  },
  {
    path: '/auctions/:id',
    name: 'auction',
    props: true,
    component: () => import('@/views/auctions/Auction.vue'),
  },
  {
    path: '/auctions',
    name: 'auctions',
    component: () => import('@/views/auctions/Auctions.vue'),
  },
];
export default auctionRoutes;
