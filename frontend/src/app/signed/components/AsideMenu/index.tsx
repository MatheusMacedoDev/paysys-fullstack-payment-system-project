import UserView from '../UserView';
import BalanceView from './BalanceView';
import { Navigator } from './Navigator';

import {
    faCircleInfo,
    faHouse,
    faRocket
} from '@fortawesome/free-solid-svg-icons';
import { ReactNode } from 'react';

interface AsideMenuProps {
    children: ReactNode;
}

export default function AsideMenu({ children }: AsideMenuProps) {
    return (
        <aside className="bg-gray-900 w-80 h-screen hidden lg:block sticky shadow-xl rounded-tr-xl rounded-br-xl p-10">
            <UserView size="big" />
            <BalanceView />

            <Navigator.Container>
                <Navigator.Section sectionTitle="Início" sectionIcon={faRocket}>
                    <Navigator.Item
                        itemHref="/"
                        itemTitle="Casa"
                        itemIcon={faHouse}
                    />
                    <Navigator.Item
                        itemHref="/"
                        itemTitle="Sobre"
                        itemIcon={faCircleInfo}
                    />
                </Navigator.Section>

                {children}
            </Navigator.Container>
        </aside>
    );
}
