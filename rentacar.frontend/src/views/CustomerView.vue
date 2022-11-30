<template>
  <v-row>
    <v-col cols="6">
      <v-form class="pa-5" ref="form">
        <v-row>
          <v-col cols="5">
            <v-text-field
              v-model="customer.firstname"
              label="Firstname"
              required
            ></v-text-field>
          </v-col>
          <v-col cols="5">
            <v-text-field
              v-model="customer.lastname"
              label="Lastname"
              required
            ></v-text-field>
          </v-col>
          <v-col cols="2">
            <v-text-field
              v-model="customer.age"
              label="Age"
              required
            ></v-text-field>
          </v-col>
        </v-row>
        <v-row>
          <v-col cols="6">
            <v-text-field
              v-model="customer.email"
              label="E-Mail"
              required
              type="email"
            ></v-text-field>
          </v-col>
          <v-col cols="6">
            <v-text-field
              v-model="customer.phone"
              label="Phone"
              required
            ></v-text-field>
          </v-col>
        </v-row>

        <v-row>
          <v-col cols="4">
            <v-text-field
              v-model="customer.city"
              label="City"
              required
            ></v-text-field>
          </v-col>
          <v-col cols="4">
            <v-text-field
              v-model="customer.region"
              label="Region"
              required
            ></v-text-field>
          </v-col>
          <v-col cols="4">
            <v-text-field
              v-model="customer.postalCode"
              label="Postal Code"
              required
            ></v-text-field>
          </v-col>
        </v-row>
        <v-textarea
          v-model="customer.address"
          label="Address"
          required
          rows="2"
        ></v-textarea>

        <v-btn
          color="primary"
          class="mr-4"
          @click="
            customer.id === 0 ? createCustomer() : updateCustomer(customer.id)
          "
        >
          Submit</v-btn
        >
      </v-form>
    </v-col>
  </v-row>
  <v-row>
    <v-col cols="12">
      <v-table theme="dark" height="70vh" class="pa-4">
        <thead>
          <tr>
            <th class="text-left">Firstname</th>
            <th class="text-left">Lastname</th>
            <th class="text-left">Age</th>
            <th class="text-left">Email</th>
            <th class="text-left">Phone</th>
            <th class="text-left">Address</th>
            <th class="text-left">City</th>
            <th class="text-left">Region</th>
            <th class="text-left">Postal Code</th>
            <th class="text-left">#</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="customer in customers" :key="'customer-' + Math.random()">
            <td>{{ customer.firstname }}</td>
            <td>{{ customer.lastname }}</td>
            <td>{{ customer.age }}</td>
            <td>{{ customer.email }}</td>
            <td>{{ customer.phone }}</td>
            <td>{{ customer.address }}</td>
            <td>{{ customer.city }}</td>
            <td>{{ customer.region }}</td>
            <td>{{ customer.postalCode }}</td>
            <td>
              <button @click="rentedCars(customer.id)" class="me-1">
                <v-icon icon="mdi-car" color="success" />
              </button>
              <button @click="editCustomer(customer.id)" class="me-1">
                <v-icon icon="mdi-pencil" color="primary" />
              </button>
              <button @click="deleteCustomer(customer.id)">
                <v-icon color="red" icon="mdi-trash-can" />
              </button>
            </td>
            <Dialog
              :title="`Rented Cars by ${customer.firstname} ${customer.lastname}`"
              :state="dialogState"
              :componentProps="[rentals]"
              :component="CustomerRentedCars"
              @close="closeDialog()"
              :key="Math.random()"
            />
          </tr>
        </tbody>
      </v-table>
    </v-col>
  </v-row>
</template>
<script setup>
import { inject, onMounted, ref } from "vue";
import Dialog from "@/components/Dialog.vue";
import CustomerRentedCars from "@/components/CustomerRentedCars.vue";

const axios = inject("axios");
let customer = ref({
  firstname: "",
  lastname: "",
  age: 0,
  email: "",
  phone: "",
  address: "",
  city: "",
  region: "",
  postalCode: "",
});
let customers = ref([]);
let rentals = ref([]);
let dialogState = ref(false);
onMounted(() => {
  axios.get("http://localhost:5270/api/Customer").then((response) => {
    customers.value = response.data;
  });
});
const closeDialog = () => {
  dialogState.value = false;
};
const rentedCars = (id) => {
  axios
    .get(`http://localhost:5270/api/Customer/getRentals?customerId=${id}`)
    .then((response) => {
      rentals.value = response.data;
    });

  dialogState.value = true;
};

const createCustomer = async () => {
  let status = await axios.post(
    "http://localhost:5270/api/Customer",
    customer.value
  );
  if (status) {
    customers.value.push(customer.value);
    location.reload();
  }
};
const editCustomer = (id) => {
  customer.value = customers.value.find((c) => c.id === id);
};
const updateCustomer = async (id) => {
  let status = await axios.put(
    "http://localhost:5270/api/Customer",
    customer.value
  );
  if (status) {
    customers.value.push(customer.value);
    let index = customers.value.indexOf(id);
    customers.value.splice(index, 1);
    location.reload();
  }
};
const deleteCustomer = async (id) => {
  let status = await axios.delete(
    `http://localhost:5270/api/Customer?id=${id}`
  );
  if (status) {
    let index = customers.value.indexOf(id);
    customers.value.splice(index, 1);
  }
};
</script>
<style></style>
