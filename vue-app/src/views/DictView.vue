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
      <b-button @click="deleteWords" class="m-4">Удалить</b-button>
    </div>
    <b-table
      :data="storage.items"
      :columns="columns"
      :checked-rows.sync="checkedRows"
      checkable
      checkbox-position="left"
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
export default class DictView extends Vue {
  storage = storage;
  newWord: string | null = null;
  newTranslation: string | null = null;

  columns = [
    { field: "Word", label: "Слово", centered: true },
    { field: "Translation", label: "Перевод", centered: true },
  ];

  checkedRows: [] = [];

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

  deleteWords() {
    if (this.checkedRows && this.checkedRows.length !== 0) {
      axios.post(
        "http://localhost:43692/api/info/deleterecords",
        this.checkedRows.map((q: any) => q.Id)
      );

      storage.items = storage.items.filter(
        (q: any) => !this.checkedRows.map((w: any) => w.Id).includes(q.Id)
      );

      this.checkedRows = [];
    }
  }
}
</script>
