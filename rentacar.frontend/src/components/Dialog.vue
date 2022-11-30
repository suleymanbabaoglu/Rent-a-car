<template>
  <div class="text-center">
    <v-dialog v-model="dialog">
      <v-card>
        <v-card-title class="pa-4 text-center">{{ title }}</v-card-title>
        <v-card-text>
          <component :is="component" :props="componentProps"/>
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" block @click="closeDialog">Close</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script setup>
const props = defineProps(["title", "state", "component", "componentProps"]);
let dialog;
dialog = props.state;

const emit = defineEmits(["close"]);

function closeDialog() {
  emit("close");
}
</script>

<style scoped></style>
