<template>
  <div>
    <div id="picture-picker">
      <div id="photo-overview" v-if="containImage"></div>
      <div id="picker" v-else>
        <div id="content">
          <div id="text">
            <unicon name="camera" width="120" height="100" fill="#494949" />
            <h1>Kliknij by dodać</h1>
          </div>
        </div>
        <input type="file" name="" id="" @change="imageUpload" />
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'offer-picture-picker',

  data() {
    return {
      containImage: false,
      image: null,
    };
  },

  methods: {
    imageUpload(e) {
      this.image = e.target.files;
      console.log(this.image[0]);
    },
  },
};
</script>

<style lang="scss">
#picture-picker {
  display: flex;
  flex-direction: column;
  align-items: center;

  #photo-overview {
    background: grey;
    width: 25vw;
    height: 40vh;
  }

  #picker {
    display: flex;
    justify-content: center;
    align-items: center;
    border: 3px dotted rgb(129, 129, 129);
    width: 20vw;
    height: 30vh;

    #content {
      display: flex;
      align-items: center;
      justify-content: center;
      flex-direction: column;

      #text {
        display: flex;
        flex-direction: column;
        align-items: center;
        h1 {
          color: rgb(165, 165, 165);
        }
      }
    }

    input[type='file'] {
      opacity: 0;
      width: 20vw;
      height: 30vh;
      position: absolute;
      cursor: pointer;
    }
  }
}

@media screen and(max-width: $tablet) {
  #picture-picker {
    #photo-overview,
    #picker {
      width: 80vw;
      height: 40vh;
    }
  }
}
</style>
