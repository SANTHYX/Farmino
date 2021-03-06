import loacalStorageManager from '../plugins/localStorageManager';
import store from '../store/store';

export const isFarmer = (to, from, next) => {
  if (!loacalStorageManager.isAuthorized()) {
    next({ name: 'login', query: { redirect: to.fullPath } });
  }
  if (store.state.offer.offer.farmer.user.userName === loacalStorageManager.getUserName()) {
    next(false);
  } else next();
};

export const isAuthorized = (to, from, next) => {
  if (!loacalStorageManager.isAuthorized()) {
    next({ path: '*' });
  } else next();
};
