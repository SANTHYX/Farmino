<template>
  <div>
    <div id="summary-view">
      <summary-template />
    </div>
  </div>
</template>

<script>
import SummaryTemplate from '@/components/templates/SummaryTemplate.vue';

export default {
  name: 'summary-view',

  components: { SummaryTemplate },
};
</script>

<style lang="scss" scoped>
#summary-view {
  @include flex-centred-site;
}
</style>
