import { useCountStore } from "../store/use-store";

export default function DisplayContador() {
  const { contador } = useCountStore();
  return (
    <div>
      <h3>Contador: {contador}</h3>
    </div>
  );
}
