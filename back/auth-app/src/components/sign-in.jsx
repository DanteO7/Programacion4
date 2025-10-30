import { Button, Label, TextInput } from "flowbite-react";
import { useForm } from "react-hook-form";
import { useAuthStore } from "../store/auth-store";
import { signIn } from "../services/auth";
import { useMutation } from "@tanstack/react-query";

export default function SignIn() {
  const { register, handleSubmit } = useForm();

  const { login } = useAuthStore();
  const mutation = useMutation({
    mutationKey: ["signin"],
    mutationFn: signIn,
    onSuccess: login,
  });

  const onSubmit = (credentials) => mutation.mutate(credentials);

  return (
    <>
      <form
        onSubmit={handleSubmit(onSubmit)}
        className="flex max-w-md flex-col gap-4 m-auto mt-10"
      >
        <div>
          <div className="mb-2 block">
            <Label htmlFor="emailOrUsername">Your email</Label>
          </div>
          <TextInput
            id="emailOrUsername"
            type="text"
            placeholder="pepe123"
            required
            {...register("emailOrUsername")}
          />
        </div>
        <div>
          <div className="mb-2 block">
            <Label htmlFor="password">Your password</Label>
          </div>
          <TextInput
            id="password"
            type="password"
            required
            {...register("password")}
          />
        </div>
        <Button type="submit">Submit</Button>
      </form>
    </>
  );
}
