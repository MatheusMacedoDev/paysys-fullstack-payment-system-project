import {
    faCoins,
    faFileInvoiceDollar,
    faRightLeft
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
                    itemTitle="Realizar pagamento"
                    itemIcon={faCoins}
                    itemHref="/"
                />
                <Navigator.Item
                    itemTitle="Extrato"
                    itemIcon={faFileInvoiceDollar}
                    itemHref="/"
                />
            </Navigator.Section>
        </AsideMenu>
    );
}
