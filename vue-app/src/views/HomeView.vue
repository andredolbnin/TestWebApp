<template>
  <div class="home">
    <b-carousel>
      <b-carousel-item v-for="(carousel, i) in carousels" :key="i">
        <section :class="`hero is-medium is-${carousel.color}`">
          <div class="hero-body has-text-centered">
            <h1 class="title">{{ carousel.text }}</h1>
          </div>
        </section>
      </b-carousel-item>
    </b-carousel>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({
  components: {},
})
export default class HomeView extends Vue {
  carousels = [
    { text: "London", color: "primary" },
    { text: "is", color: "info" },
    { text: "the capital", color: "success" },
    { text: "of Great", color: "warning" },
    { text: "Britain", color: "danger" },
  ];
}
</script>
