import Image from 'next/image';

export default function PaySysLogoRounded() {
    return (
        <div className="w-28 h-28 bg-gradient-to-t from-gray-500 to-gray-800 rounded-full flex align-center justify-center">
            <Image
                src="paysys-logo.svg"
                alt="Logomarca do PaySys"
                width="70"
                height="70"
            />
        </div>
    );
}
