import loacalStorageManager from '../plugins/localStorageManager';
import store from '../store/store';

const isFarmer = (to, from, next) => {
  if (!loacalStorageManager.isAuthorized()) {
    next({ name: 'login', query: { redirect: to.fullPath } });
  }
  if (store.state.offer.offer.farmer.user.userName === loacalStorageManager.getUserName()) {
    next(false);
  } else next();
};

const haveProfile = async (to, from, next) => {
  await store.dispatch('user/GET_USER', store.state.auth.userName);
  if (!loacalStorageManager.isAuthorized()) {
    next({ path: '*' });
  }
  if (store.state.user.user.profile === null) {
    next({ name: 'create-profile', query: { redirect: to.fullPath } });
  } else next();
};

const isAuthorized = (to, from, next) => {
  if (!loacalStorageManager.isAuthorized()) {
    next({ path: '*' });
  } else next();
};

export { isAuthorized, isFarmer, haveProfile };
