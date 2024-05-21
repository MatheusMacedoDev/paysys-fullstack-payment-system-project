import {
    faChartSimple,
    faFileInvoiceDollar,
    faMoneyBillWave
} from '@fortawesome/free-solid-svg-icons';
import AsideMenu from './AsideMenu';
import { Navigator } from './AsideMenu/Navigator';

interface ShopkeeperAsideMenuProps {
    isMobile: boolean;
}

export default function ShopkeeperAsideMenu({
    isMobile
}: ShopkeeperAsideMenuProps) {
    return (
        <AsideMenu isMobile={isMobile}>
            <Navigator.Section
                sectionTitle="Recebimentos"
                sectionIcon={faMoneyBillWave}
            >
                <Navigator.Item
                    itemTitle="Gráfico Informativo"
                    itemIcon={faChartSimple}
                    itemHref="/"
                />
                <Navigator.Item
                    itemTitle="Histórico"
                    itemIcon={faFileInvoiceDollar}
                    itemHref="/"
                />
            </Navigator.Section>
        </AsideMenu>
    );
}
