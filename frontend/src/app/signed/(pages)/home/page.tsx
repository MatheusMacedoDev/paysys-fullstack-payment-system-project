import Image from 'next/image';

export default function HomePage() {
    return (
        <div className="h-screen flex flex-col justify-center items-center p-5">
            <Image
                src="/undraw-working.svg"
                alt="Pessoas trabalhando"
                className="mb-14"
                width={282}
                height={160}
                draggable={false}
            />
            <p className="font-black text-5xl text-green-300 text-center mb-7 w-full md:w-[540px]">
                O PaySys está trabalhando por você.
            </p>
            <p className="font-normal text-xl text-green-300">
                Aproveite todos os nossos benefícios.
            </p>
        </div>
    );
}
