import {
    faFileInvoiceDollar,
    faGear,
    faRightLeft,
    faShieldHalved,
    faShop,
    faUser,
    faUsers
} from '@fortawesome/free-solid-svg-icons';
import AsideMenu from './AsideMenu';
import { Navigator } from './AsideMenu/Navigator';

interface CommonUserAsideMenuProps {
    isMobile: boolean;
}

export default function CommonUserAsideMenu({
    isMobile
}: CommonUserAsideMenuProps) {
    return (
        <AsideMenu isMobile={isMobile}>
            <Navigator.Section
                sectionTitle="Transações"
                sectionIcon={faRightLeft}
            >
                <Navigator.Item
                    itemTitle="Histórico Global"
                    itemIcon={faFileInvoiceDollar}
                    itemHref="/"
                />
            </Navigator.Section>
            <Navigator.Section
                sectionTitle="Gerenciamento"
                sectionIcon={faGear}
            >
                <Navigator.Item
                    itemTitle="Tipos de Usuário"
                    itemIcon={faUsers}
                    itemHref="/"
                />
                <Navigator.Item
                    itemTitle="Usuários Comuns"
                    itemIcon={faUser}
                    itemHref="/"
                />
                <Navigator.Item
                    itemTitle="Lojistas"
                    itemIcon={faShop}
                    itemHref="/"
                />
                <Navigator.Item
                    itemTitle="Administradores"
                    itemIcon={faShieldHalved}
                    itemHref="/"
                />
            </Navigator.Section>
        </AsideMenu>
    );
}
