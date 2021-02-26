<template>
  <div>
    <div id="not-found">
      <unicon name="info-circle" width="80" height="80" fill="lightgrey"></unicon>
      <h1>Brak Wyników</h1>
    </div>
  </div>
</template>

<style lang="scss" scoped>
#not-found {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;

  h1 {
    color: rgb(192, 192, 192);
  }
}
</style>
