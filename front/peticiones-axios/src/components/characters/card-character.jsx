import { Link } from "wouter";

export default function CardCharacter({ id, image, name, ki, description }) {
  return (
    <Link
      href={`/characters/${id}`}
      className="bg-gray-950 card w-96 shadow-sm border-2 border-transparent transition ease duration-2 00 hover:border-white "
    >
      <figure className="flex flex-col">
        <img src={image} alt={`imagen de ${name}`} className=" h-80 " />
        <figcaption>Ki: {ki}</figcaption>
      </figure>
      <div className="card-body">
        <h2 className="card-title">{name}</h2>
        <p className=" h-30 overflow-y-scroll ">{description}</p>
        <div className="card-actions justify-center">
          <button className="btn btn-primary">Más detalles</button>
        </div>
      </div>
    </Link>
  );
}
