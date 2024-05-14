'use client';

import PaySysLogoRounded from '@/components/PaySysLogoRounded';
import LinkWithIcon from './LinkWithIcon';
import CloseNavigatorButton from './CloseNavigatorButton';

import { useSearchParams } from 'next/navigation';

import { faKey, faUserPlus } from '@fortawesome/free-solid-svg-icons';

export default function AsideNavigatorModal() {
    const searchParams = useSearchParams();
    const navigator = searchParams.get('navigator');

    return (
        <>
            {navigator && (
                <dialog className="fixed left-0 top-0 w-full h-full bg-gray-900 bg-opacity-50 z-50 overflow-auto backdrop-blur flex">
                    <aside className="bg-green-300 h-full w-3/5 p-12 flex flex-col items-center relative">
                        <CloseNavigatorButton />
                        <PaySysLogoRounded />

                        <div className="flex flex-col items-center gap-11 mt-20">
                            <LinkWithIcon
                                icon={faKey}
                                href="login"
                                text="Entrar"
                            />

                            <LinkWithIcon
                                icon={faUserPlus}
                                href="register"
                                text="Cadastrar"
                            />
                        </div>
                    </aside>
                </dialog>
            )}
        </>
    );
}
