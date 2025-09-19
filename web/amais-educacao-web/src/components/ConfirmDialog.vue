<template>
  <v-dialog v-model="dialog" max-width="500">
    <v-card>
      <v-card-title class="headline">
        {{ title }}
      </v-card-title>
      <v-card-text>
        {{ message }}
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="secondary" @click="cancel">
          Cancelar
        </v-btn>
        <v-btn color="error" @click="confirm">
          Excluir
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup>
import { ref } from 'vue';

const props = defineProps({
  title: String,
  message: String,
});

const emit = defineEmits(['confirm']);

const dialog = ref(false);
const itemToConfirm = ref(null);

const open = (item) => {
  itemToConfirm.value = item;
  dialog.value = true;
};

const confirm = () => {
  emit('confirm', itemToConfirm.value);
  dialog.value = false;
};

const cancel = () => {
  dialog.value = false;
};

defineExpose({
  open,
});
</script>