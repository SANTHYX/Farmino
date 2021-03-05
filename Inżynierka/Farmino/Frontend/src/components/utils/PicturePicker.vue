<template>
  <div>
    <div id="picture-picker">
      <div id="photo-overview" v-if="containImage">
        <img :src="image" alt="" id="image-handler" />
      </div>
      <div id="picker" v-else>
        <div id="content">
          <div id="text">
            <unicon name="camera" width="120" height="100" fill="#494949" />
            <h1>Kliknij by dodać</h1>
          </div>
        </div>
      </div>
      <input type="file" @change="dockImage" />
    </div>
  </div>
</template>

<script>
export default {
  name: 'offer-picture-picker',

  data() {
    return {
      containImage: false,
      imageFile: null,
      image: null,
    };
  },

  methods: {
    dockImage(e) {
      if (e.target.files[0].type.match('image.*')) {
        this.imageFile = e.target.files;
        this.containImage = true;
        this.previewImage(this.imageFile[0]);
      }
    },

    previewImage(file) {
      const fileReader = new FileReader();

      fileReader.onload = e => {
        this.image = e.target.result;
      };

      fileReader.readAsDataURL(file);
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
    width: 25vw;
    height: 40vh;

    #image-handler {
      width: 25vw;
      height: 40vh;
      object-fit: cover;
    }
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
  }
  input[type='file'] {
    opacity: 0;
    width: 20vw;
    height: 30vh;
    position: absolute;
    cursor: pointer;
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
