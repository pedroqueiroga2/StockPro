const ModalService = {
    /**
     * Abre um modal dinâmico.
     * @param {string} title Titulo do modal.
     * @param {string} url Rota da qual a View/Conteúdo será buscado (opcional).
     * @param {string} width CSS width (ex: '500px' ou '50%').
     * @param {string} height CSS height (ex: '400px' ou 'auto').
     */
    openModal: async function (title, url = null, width = '500px', height = 'auto') {
        // 1. Remove modais antigos para evitar duplicação no DOM
        const existingModal = document.getElementById('dynamicAppModal');
        if (existingModal) {
            existingModal.remove();
        }

        // 2. Busca o conteúdo se uma URL for passada, senão será só um modal genérico
        let modalBodyContent = '<p>Carregando...</p>';
        if (url) {
            try {
                const response = await fetch(url);
                if (response.ok) {
                    modalBodyContent = await response.text();
                } else {
                    modalBodyContent = '<p class="text-danger">Erro ao carregar o conteúdo.</p>';
                }
            } catch (error) {
                console.error("Erro na requisição da modal:", error);
                modalBodyContent = '<p class="text-danger">Ocorreu um erro de rede.</p>';
            }
        } else {
            modalBodyContent = '<p>Nenhum conteúdo definido.</p>';
        }

        // 3. Constrói o HTML do Modal
        const modalHtml = `
            <div class="modal fade" id="dynamicAppModal" tabindex="-1" aria-labelledby="dynamicAppModalLabel" aria-hidden="true">
                <div class="modal-dialog" style="max-width: ${width}; height: ${height};">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="dynamicAppModalLabel">${title}</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            ${modalBodyContent}
                        </div>
                    </div>
                </div>
            </div>
        `;

        // 4. Adiciona o modal no body
        document.body.insertAdjacentHTML('beforeend', modalHtml);

        // 5. Inicializa e exibe o modal usando a API nativa do Bootstrap 5
        const modalElement = document.getElementById('dynamicAppModal');
        const modalInstance = new bootstrap.Modal(modalElement);
        modalInstance.show();

        // 6. Limpa o DOM automaticamente após o modal ser fechado (evita lixo de HTML na sua página)
        modalElement.addEventListener('hidden.bs.modal', function () {
            modalElement.remove();
        });
    }
};