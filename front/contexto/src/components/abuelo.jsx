import Padre from "./padre";

export default function Abuelo() {
  return (
    <div className="border-2 border-blue-500">
      <h2>Soy el Abuelo</h2>
      <Padre />
    </div>
  );
}
