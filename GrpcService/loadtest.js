import grpc from 'k6/net/grpc';
import { check, sleep } from 'k6';

export const options = {
  discardResponseBodies: true,
  scenarios: {
    contacts: {
      executor: 'per-vu-iterations',
      vus: 10,
      iterations: 10,
      maxDuration: '30s',
    },
  },
};

const client = new grpc.Client();
client.load(['protos'], 'employee.proto');

export default () => {
  console.log('Connecting...');

  client.connect('localhost:5007', {
    //plaintext: true,
  });

  console.log('Sending data...');

  const data = { Id: 'Jack' };
  const response = client.invoke(
    'employeegrpc.EmployeeService/GetEmployees',
    data
  );

  check(response, {
    'status is OK': (r) => r && r.status === grpc.StatusOK,
  });

  console.log(JSON.stringify(response.message));

  client.close();
  sleep(1);
};
