<template>
  <div>
    <div class="columns ml-1">
      <b-input
        placeholder="Новое слово"
        v-model="newWord"
        style="width: 400px"
        class="m-4"
      ></b-input>
      <b-input
        placeholder="Перевод"
        v-model="newTranslation"
        style="width: 400px"
        class="m-4"
      ></b-input>
      <b-button @click="addNewWord" class="m-4">Добавить</b-button>
    </div>
    <b-table
      :data="storage.items"
      :columns="columns"
      bordered
      class="mx-4"
    ></b-table>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { storage } from "@/services/storage";
import axios from "axios";

@Component({
  components: {},
})
export default class HomeView extends Vue {
  storage = storage;
  newWord: string | null = null;
  newTranslation: string | null = null;

  columns = [
    { field: "Word", label: "Слово", centered: true },
    { field: "Translation", label: "Перевод", centered: true },
  ];

  mounted() {
    if (storage.items.length == 0) {
      axios
        .get("http://localhost:43692/api/info/records")
        .then((response: any) => {
          storage.items = response.data;
          console.log("loaded");
        })
        .catch((error: any) => alert(error));
    }
  }

  addNewWord() {
    if (!this.newWord || !this.newTranslation) return;

    storage.items.push({
      Word: this.newWord,
      Translation: this.newTranslation,
    });

    axios.post("http://localhost:43692/api/info/addrecord", {
      Word: this.newWord,
      Translation: this.newTranslation,
    });

    this.newWord = null;
    this.newTranslation = null;
  }
}
</script>
