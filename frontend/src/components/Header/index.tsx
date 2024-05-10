import Image from 'next/image';

import MobileMenuButton from './MobileMenuButton';

export default function Header() {
    return (
        <header className="bg-gray-900 flex justify-between items-center h-20 px-8 shadow-md">
            <Image
                src="paysys-logo.svg"
                alt="Logomarca do PaySys"
                className="w-14"
                width="70"
                height="70"
            />

            <MobileMenuButton />
        </header>
    );
}
