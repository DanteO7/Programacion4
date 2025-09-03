import { useForm } from "react-hook-form";
import Input from "./components/input";
import { userValidation } from "./validation/user-validation";
import { zodResolver } from "@hookform/resolvers/zod";

function App() {
  const {
    handleSubmit,
    register,
    formState: { errors },
  } = useForm({ resolver: zodResolver(userValidation) });

  const onSubmit = (data) => console.log(data);

  return (
    <>
      <h1>Form</h1>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Input
          type="text"
          register={register}
          error={errors?.username}
          label="Username"
        />
        <Input
          type="text"
          register={register}
          error={errors?.email}
          label="Email"
        />
        <Input
          type="password"
          register={register}
          error={errors?.password}
          label="Password"
        />
        <Input
          type="password"
          register={register}
          error={errors?.confirmPassword}
          label="Confirm password"
        />

        <button>Confirm</button>
      </form>
      ;
    </>
  );
}

export default App;
