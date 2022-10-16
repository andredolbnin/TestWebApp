import { Component, Vue } from "vue-property-decorator";

@Component
class Storage extends Vue {
  items: any = [];
}

export const storage = new Storage();
