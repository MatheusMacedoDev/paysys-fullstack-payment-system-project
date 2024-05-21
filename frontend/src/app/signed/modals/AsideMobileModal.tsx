import { useSearchParams } from 'next/navigation';
import { ReactNode } from 'react';

interface AsideMobileModal {
    children: ReactNode;
}

export default function AsideMobileModal({ children }: AsideMobileModal) {
    const searchParams = useSearchParams();
    const signedMenu = searchParams.get('signed-menu');

    return (
        signedMenu && (
            <dialog className="fixed left-0 top-0 w-full h-full bg-green-100 bg-opacity-80 z-50 overflow-auto backdrop-blur flex">
                {children}
            </dialog>
        )
    );
}
