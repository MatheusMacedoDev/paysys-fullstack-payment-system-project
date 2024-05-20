import {
    faCoins,
    faFileInvoiceDollar,
    faRightLeft
} from '@fortawesome/free-solid-svg-icons';
import AsideMenu from './AsideMenu';
import { Navigator } from './AsideMenu/Navigator';

export default function CommonUserAsideMenu() {
    return (
        <AsideMenu>
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
