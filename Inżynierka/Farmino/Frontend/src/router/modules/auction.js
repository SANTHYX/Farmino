const auctionRoutes = [
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
];
export default auctionRoutes;
