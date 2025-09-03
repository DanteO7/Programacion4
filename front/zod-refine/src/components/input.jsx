import { useId } from "react";

export default function Input({ type, register, error, label }) {
  const id = useId();

  return (
    <div className="control">
      <label htmlFor={id}>{label}</label>
      <input type={type} id={id} {...register(type)} />
      {error && <span className="error">{error.message}</span>}
    </div>
  );
}
