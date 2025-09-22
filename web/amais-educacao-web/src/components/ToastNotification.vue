<template>
  <v-snackbar
    v-model="toast.show"
    :color="toast.color"
    :timeout="3000"
    location="top"
    :offset="30"
  >
    {{ toast.message }}
  </v-snackbar>
</template>

<script setup>
import { useStudentStore } from '@/stores/studentStore';
import { storeToRefs } from 'pinia';

const studentStore = useStudentStore();
const { toast } = storeToRefs(studentStore);
</script>