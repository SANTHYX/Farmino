const auctionRoutes = [
  {
    path: '/auctions',
    name: 'auctions',
    component: () => import('@/views/auctions/Auctions.vue'),
  },
  {
    path: '/auctions/my-auctions',
    name: 'my-auctions',
    component: () => import('@/views/auctions/MyAuctions.vue'),
  },
  {
    path: '/auctions/followed',
    name: 'followed',
    component: () => import('@/views/auctions/FollowedAuctions.vue'),
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
    component: () => import('@/views/auctions/AuctionCreate.vue'),
  },
];
export default auctionRoutes;
