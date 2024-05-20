import Image from 'next/image';

export default function PaySysLogoRounded() {
    return (
        <div className="w-24 h-24 md:w-28 md:h-28 bg-gradient-to-t from-gray-500 to-gray-800 rounded-full flex align-center justify-center">
            <Image
                src="/paysys-logo.svg"
                alt="Logomarca do PaySys"
                className="w-14 md:w-16 h-14 m-auto"
                width="70"
                height="70"
            />
        </div>
    );
}
